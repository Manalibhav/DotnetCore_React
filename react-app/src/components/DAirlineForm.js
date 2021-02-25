import React, { useState, useEffect } from "react";
import { Grid, TextField, withStyles, FormControl, InputLabel, Select, MenuItem, Button, FormHelperText } from "@material-ui/core";
import useForm from "./useForm";
import { connect } from "react-redux";
import * as actions from "../actions/dAirline";
import { useToasts } from "react-toast-notifications";

const styles = theme => ({
    root: {
        '& .MuiTextField-root': {
            margin: theme.spacing(1),
            minWidth: 230,
        }
    },
    formControl: {
        margin: theme.spacing(1),
        minWidth: 230,
    },
    smMargin: {
        margin: theme.spacing(1)
    }
})

const initialFieldValues = {
    airlinename: '',
    noofdesti: '',
    slogan: '',
    headquar: ''
   
}

const DAirlineForm = ({ classes, ...props }) => {

    //toast msg.
    const { addToast } = useToasts()

    //validate()
    //validate({fullName:'jenny'})
    const validate = (fieldValues = values) => {
        let temp = { ...errors }
        if ('airlinename' in fieldValues)
            temp.airlinename = fieldValues.airlinename ? "" : "This field is required."
        if ('noofdesti' in fieldValues)
            temp.noofdesti = fieldValues.noofdesti ? "" : "This field is required."
        if ('slogan' in fieldValues)
            temp.slogan = fieldValues.slogan ? "" : "This field is required."
        if ('headquar' in fieldValues)
            temp.headquar= fieldValues.headquar? "" : "Email is not valid."
        setErrors({
            ...temp
        })

        if (fieldValues == values)
            return Object.values(temp).every(x => x == "")
    }

    const {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange,
        resetForm
    } = useForm(initialFieldValues, validate, props.setCurrentId)

    //material-ui select
   /* const inputLabel = React.useRef("");
    const [labelWidth, setLabelWidth] = React.useState(0);
    React.useEffect(() => {
        setLabelWidth(inputLabel.current.offsetWidth);
    }, []);*/

    const handleSubmit = e => {
        e.preventDefault()
        if (validate()) {
            const onSuccess = () => {
                resetForm()
                addToast("Submitted successfully", { appearance: 'success' })
            }
            if (props.currentId == 0)
                props.createDCandidate(values, onSuccess)
            else
                props.updateDCandidate(props.currentId, values, onSuccess)
        }
    }

    useEffect(() => {
        if (props.currentId != 0) {
            setValues({
                ...props.dCandidateList.find(x => x.id == props.currentId)
            })
            setErrors({})
        }
    }, [props.currentId])

    return (
        <form autoComplete="off" noValidate className={classes.root} onSubmit={handleSubmit}>
            <Grid container>
                <Grid item xs={4}>
                    <TextField
                        name="airlinename"
                        variant="outlined"
                        label="Airline Name"
                        value={values.airlinename}
                        onChange={handleInputChange}
                        {...(errors.airlinename && { error: true, helperText: errors.airlinename })}
                    />
                    <TextField
                        name="noofdesti"
                        variant="outlined"
                        label="Number Of Destinations"
                        value={values.noofdesti}
                        onChange={handleInputChange}
                        {...(errors.noofdesti && { error: true, helperText: errors.noofdesti })}
                    />
                    
                    <TextField
                        name="slogan"
                        variant="outlined"
                        label="Slogan"
                        value={values.slogan}
                        onChange={handleInputChange}
                        {...(errors.slogan && { error: true, helperText: errors.slogan })}
                    />
                    <TextField
                        name="headquar"
                        variant="outlined"
                        label="Headquarter"
                        value={values.headquar}
                        onChange={handleInputChange}
                    />
                   
                    <div>
                        <Button
                            variant="contained"
                            color="primary"
                            type="submit"
                            className={classes.smMargin}
                        >
                            Submit
                        </Button>
                        <Button
                            variant="contained"
                            className={classes.smMargin}
                            onClick={resetForm}
                        >
                            Reset
                        </Button>
                    </div>
                </Grid>
            </Grid>
        </form>
    );
}


const mapStateToProps = state => ({
    dCandidateList: state.dAirline.list
})

const mapActionToProps = {
    createDCandidate: actions.create,
    updateDCandidate: actions.update
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(DAirlineForm));