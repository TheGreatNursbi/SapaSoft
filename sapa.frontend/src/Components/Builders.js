import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../Actions/builder";
import { Grid, Paper, TableContainer, Table, TableHead, TableRow, TableCell, TableBody, withStyles, ButtonGroup, Button } from "@material-ui/core";
import BuilderForm from "../Components/BuilderForm";
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

const Builder = ({classes, ...props}) => {
    const [currentId, setCurrentId] = useState(0)
    const {addToast } = useToasts();
    const onDelete = id => {
        if(window.confirm('Are you sure?')){
            props.deleteBuilder(id, () => addToast("Deleted successfully", {appearance: 'info'}))
            setCurrentId(0)
        }
    }

    useEffect(() => {
        props.fetchAllBuilders()
    }, [])

    return (
        <Paper className={classes.paper} elevation={3}>
            <Grid container>
                <Grid item xs={5}>
                    <BuilderForm {...({currentId, setCurrentId})}/>
                </Grid>
                <Grid item xs={7}>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>Name</TableCell>
                                    <TableCell>Address</TableCell>
                                    <TableCell>BIN</TableCell>
                                    <TableCell>Date</TableCell>
                                    <TableCell></TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    props.builderList.map((record, index) => {
                                        console.log(props.builderList)
                                        return (<TableRow key={index}>
                                            <TableCell>{record.name}</TableCell>
                                            <TableCell>{record.address}</TableCell>
                                            <TableCell>{record.bin}</TableCell>
                                            <TableCell>{record.activityStartDate}</TableCell>
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
    builderList: state.builder.list
})

const mapActionsToProps = {
    fetchAllBuilders: actions.fetchAll,
    deleteBuilder: actions.erase
}

export default connect(mapStateToProps, mapActionsToProps)(withStyles(styles)(Builder));