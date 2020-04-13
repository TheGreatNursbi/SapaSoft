import { combineReducers } from "redux";
// import { builder } from "./builder";
// import { businessCenter } from "./businessCenter";
import { genericReducer } from "./genericReducer"

export const reducers = combineReducers({
    builder: genericReducer,
    businessCenter: genericReducer
})