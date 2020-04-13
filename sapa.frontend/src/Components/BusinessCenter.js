import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../Actions/businessCenter";
import { Grid, Paper, TableContainer, Table, TableHead, TableRow, TableCell, TableBody, withStyles, ButtonGroup, Button } from "@material-ui/core";
import BusinessCenterForm from "../Components/BusinessCenterForm";
import EditIcon from "@material-ui/icons/Edit";
import DeleteIcon from "@material-ui/icons/Delete";
import { useToasts } from "react-toast-notifications";

const styles = theme => ({
    root: {
        "& .MuiTableCell-head": {
            fontSize: "1.25rem"
        }
    },
    paper: {
        margin: theme.spacing(2),
        padding: theme.spacing(2)
    }
})

const BusinessCenter = ({classes, ...props}) => {
    const [currentId, setCurrentId] = useState(0)
    const {addToast } = useToasts();
    const onDelete = id => {
        if(window.confirm('Are you sure?')){
            props.deleteBusinessCenter(id, () => addToast("Deleted successfully", {appearance: 'info'}))
            setCurrentId(0)
        }
    }

    useEffect(() => {
        props.fetchAllBusinessCenters()
    }, [])

    return (
        <Paper className={classes.paper} elevation={3}>
            <Grid container>
                <Grid item xs={5}>
                    <BusinessCenterForm {...({currentId, setCurrentId})}/>
                </Grid>
                <Grid item xs={7}>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>Name</TableCell>
                                    <TableCell>Address</TableCell>
                                    <TableCell>Height</TableCell>
                                    <TableCell>Floors</TableCell>
                                    <TableCell>Price</TableCell>
                                    <TableCell>Builder name</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    props.businessCenterList.map((record, index) => {
                                        return (<TableRow key={index}>
                                            <TableCell>{record.name}</TableCell>
                                            <TableCell>{record.address}</TableCell>
                                            <TableCell>{record.height}</TableCell>
                                            <TableCell>{record.floors}</TableCell>
                                            <TableCell>{record.price}</TableCell>
                                            <TableCell>
                                                <ButtonGroup variant="text">
                                                    <Button><EditIcon color="primary" onClick={() =>{setCurrentId(record.id)}}/></Button>
                                                    <Button><DeleteIcon color="secondary"onClick={() => onDelete(record.id)}/></Button>
                                                </ButtonGroup>
                                            </TableCell>
                                        </TableRow>)
                                    })
                                }
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Grid>
            </Grid>
        </Paper>
     )
}

const mapStateToProps = state => ({
    businessCenterList: state.businessCenter.list
})

const mapActionsToProps = {
    fetchAllBusinessCenters: actions.fetchAll,
    deleteBusinessCenter: actions.erase
}

export default connect(mapStateToProps, mapActionsToProps)(withStyles(styles)(BusinessCenter));