import React, {useState, useEffect, useRef} from "react";
import { Grid, TextField, withStyles, MenuItem, FormControl, InputLabel, Select, Button, FormHelperText, makeStyles } from "@material-ui/core";
import useForm from "./useForm";
import DateFnsUtils from '@date-io/date-fns';
import { MuiPickersUtilsProvider, KeyboardTimePicker, KeyboardDatePicker, } from '@material-ui/pickers';
import 'date-fns';
import * as actions from "../Actions/builder";
import { connect } from "react-redux";
import { useToasts } from "react-toast-notifications";

const styles = theme => ({
    root: {
        "& .MuiTextField-root": {
            margin: theme.spacing(1),
            minWidth: 460
        }
    },
    formControl:{
        margin: theme.spacing(1),
        minWidth: 460
    },
    smMargin: {
        margin: theme.spacing(1)
    },
    dateControl: {
        margin: theme.spacing(1),
        minWidth: 460
    }
})

const initialFieldValues = {
    name: '',
    address: '',
    bin: '',
    activityStartDate: '01/01/1970'
}

const BuilderForm = ({classes, ...props}) => {
    
    const [values, setValues] = useState(initialFieldValues)
    const [selectedDate, setSelectedDate] = useState(new Date());
    const [errors, setErrors] = useState({})

    const resetForm = () => {
        setValues({
            ...initialFieldValues,
            activityStartDate: '01/01/1970'
        })
        props.setCurrentId(0)
        setErrors({})
    }

    const validate = () => {
        let temp = {}
        temp.name = values.name ? "" : "This field is required."
        temp.address = values.address ? "" : "This field is required."
        temp.bin = (/^(\d{4})-(\d{4})-(\d{4})-(\d{4})$/).test(values.bin) ? "" : "This field is required."

        setErrors({
            ...temp
        })

        return Object.values(temp).every(x => x == "")
    }

    const handleInputChange = e => {
        const {name, value} = e.target
        const fieldValue = {[name]: value}

        setSelectedDate(selectedDate)

        setValues({
            ...values,
            ...fieldValue
        })
    }

    const getRightDate = (objectDate) => {
        let date = new Date(objectDate),
        month = '' + (date.getMonth() + 1),
        day = '' + date.getDate(),
        year = date.getFullYear();

        if (month.length < 2) {
            month = '0' + month;
        }

        if (day.length < 2) {
            day = '0' + day;
        }

        return [year, month, day].join('/');
    }

    const handleDateChange = (date) => {
        setValues({
            ...values,
            activityStartDate: getRightDate(date)
        })
        setSelectedDate(date);
    };

    const handleSubmit = e => {
        console.log('clicked sumbit')
        e.preventDefault()

        
        if(validate()){

            const data = {
                name: values.name,
                address: values.address,
                bin: values.bin,
                activityStartDate: getRightDate(selectedDate)
            }

            const onSuccess = () => {
                resetForm()
                addToast("Submitted successfully", {appearance: 'success'}) 
             }
             
             if (props.currentId == 0){
                 props.createBuilder(data, onSuccess)
             }else{
                 props.updateBuilder(props.currentId, data, onSuccess)
                 props.setCurrentId(0)
             }
        }
        
    }

    const {addToast } = useToasts();

    useEffect(() => {
        if (props.currentId != 0) {
            setValues({
                ...props.builderList.find(x => x.id == props.currentId),
            })
            setErrors({})
        }
    }, [props.currentId])
    return (
        <form autoComplete="off" noValidate className={classes.root} onSubmit={handleSubmit}>
            <Grid container>
                <Grid item xs={6}>
                    <TextField 
                        name="name" 
                        variant="outlined" 
                        label="Name" 
                        value={values.name} 
                        onChange={handleInputChange}
                        {...(errors.name && { error: true, helperText: errors.name})}>
                    </TextField>
                    <TextField 
                        name="address" 
                        variant="outlined" 
                        label="Address" 
                        value={values.address} 
                        onChange={handleInputChange}
                        {...(errors.address && { error: true, helperText: errors.address})}>                       
                    </TextField>
                    <TextField 
                        name="bin" 
                        variant="outlined" 
                        label="BIN" 
                        value={values.bin} 
                        onChange={handleInputChange}
                        {...(errors.bin && { error: true, helperText: errors.bin})}>
                    </TextField>
                    <MuiPickersUtilsProvider utils={DateFnsUtils}>
                    <Grid>
                    <KeyboardDatePicker
                        disableToolbar
                        variant="outlined"
                        format="dd/MM/yyyy"
                        margin="normal"
                        id="date-picker-outlined"
                        label=""
                        value={new Date(values.activityStartDate)}
                        onChange={handleDateChange}
                        KeyboardButtonProps={{
                            'aria-label': 'change date',
                        }}
                    />
                    </Grid>
                    </MuiPickersUtilsProvider>
                    <div>
                        <Button
                            className={classes.smMargin}
                            variant="contained"
                            color="primary"
                            type="submit">
                                Submit
                        </Button>
                        <Button variant="contained" className={classes.smMargin} onClick={resetForm}>
                                Reset
                        </Button>
                    </div>
                </Grid>
            </Grid>
        </form>
    )
}

const mapStateToProps = state => ({
    builderList: state.builder.list
})

const mapActionsToProps = {
    createBuilder: actions.create,
    updateBuilder: actions.update
}

export default connect(mapStateToProps, mapActionsToProps)(withStyles(styles)(BuilderForm));