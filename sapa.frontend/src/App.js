import React from 'react';
import logo from './logo.svg';
import './App.css';
import { store } from "./Actions/store";
import { Provider } from "react-redux";
import Builders from './Components/Builders';
import { Container, ButtonGroup, Button } from "@material-ui/core";
import { makeStyles } from '@material-ui/core/styles';
import ExpansionPanel from '@material-ui/core/ExpansionPanel';
import ExpansionPanelDetails from '@material-ui/core/ExpansionPanelDetails';
import ExpansionPanelSummary from '@material-ui/core/ExpansionPanelSummary';
import Typography from '@material-ui/core/Typography';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import { ToastProvider } from 'react-toast-notifications';
import BusinessCenter from './Components/BusinessCenter';

function App() {
  return (
    <Provider store={store}>
      <ToastProvider autoDismiss={true}>
        <Container maxWidth="xl">
          <Builders/>
          {/* <BusinessCenter/> */}
        </Container>
      </ToastProvider>
    </Provider>
  );
}

export default App;
