import React, {useState, useEffect} from "react";
import { Grid, TextField, withStyles, FormControl, MenuItem, InputLabel, Select, Button } from "@material-ui/core";
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
            minWidth: 460.
        }
    },
    formControl:{
        margin: theme.spacing(1),
        minWidth: 460,
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
    height: '',
    floors: '',
    address: '',
    price: '',
    builderId: '',
}

const BusinessCenterForm = ({classes, ...props}) => {
    const [values, setValues] = useState(initialFieldValues)

    const resetForm = () => {
        setValues({
            ...initialFieldValues
        })
        props.setCurrentId(0)
    }

    const handleInputChange = e => {
        const {name, value} = e.target
        const fieldValue = {[name]: value}

        setValues({
            ...values,
            ...fieldValue
        })
    }

    const handleSubmit = e => {
        console.log('clicked sumbit')
        e.preventDefault()

        const data = {
            name: values.name,
            address: values.address,
            height: values.height,
            floors: values.floors,
            price: values.price,
            builderId:  values.builderId
        }

        const onSuccess = () => {
           resetForm()
           addToast("Submitted successfully", {appearance: 'success'}) 
        }
        
        if (props.currentId == 0){
            props.createBuilder(data, onSuccess)
        }else{
            props.updateBuilder(props.currentId, data, onSuccess)
        }
    }

    useEffect(() => {
        if (props.currentId != 0) {
            setValues({
                ...props.builderList.find(x => x.id == props.currentId)
            })
        }
    }, [props.currentId])

    const {addToast } = useToasts();

    return (
        <form autoComplete="off" noValidate className={classes.root}>
            <Grid container>
                <Grid item xs={6}>
                    <TextField 
                        name="name" 
                        variant="outlined" 
                        label="Name" 
                        value={values.name} 
                        onChange={handleInputChange}>
                    </TextField>
                    <TextField 
                        name="address" 
                        variant="outlined" 
                        label="Address" 
                        value={values.address} 
                        onChange={handleInputChange}>                        
                    </TextField>
                    <TextField 
                        name="height" 
                        variant="outlined" 
                        label="Height" 
                        value={values.height} 
                        onChange={handleInputChange}>
                    </TextField>
                    <TextField 
                        name="floors" 
                        variant="outlined" 
                        label="Floors" 
                        value={values.floors} 
                        onChange={handleInputChange}>
                    </TextField>
                    <TextField 
                        name="price" 
                        variant="outlined" 
                        label="Price" 
                        value={values.price} 
                        onChange={handleInputChange}>
                    </TextField>
                    <FormControl variant="outlined" className={classes.formControl}>
                        <InputLabel>Builders</InputLabel>
                        <Select
                            name={"builderId"}
                            value={"values.builder"}
                            onChange={handleInputChange}>
                            <MenuItem value="">Select builder</MenuItem>
                            {
                                
                                props.businessCenterList.map((record, index) => {
                                    console.log(props.businessCenterList)
                                    return (
                                        <MenuItem>{record.builder.name}</MenuItem>
                                    )
                                })
                            }
                        </Select>
                    </FormControl>
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
    businessCenterList: state.businessCenter.list
})

const mapActionsToProps = {
    createBusinessCenter: actions.create,
    updateBusinessCenter: actions.update
}

export default connect(mapStateToProps, mapActionsToProps)(withStyles(styles)(BusinessCenterForm));