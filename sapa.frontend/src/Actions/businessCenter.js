import urls from "./api";

export const ACTION_TYPES = {
    CREATE: "CREATE",
    UPDATE: 'UPDATE',
    DELETE: 'DELETE',
    FETCH_ALL: 'FETCH_ALL'
}

export const fetchAll = () => dispatch => {
    console.log("fetchAll api request")
    urls.BusinessCenter.fetchAll()
        .then(response => {
                dispatch({
                    type: ACTION_TYPES.FETCH_ALL,
                    payload: response.data.data
                })
            })
            .catch(err => console.log(err))
}

export const create = (data, onSuccees) => dispatch => {
    console.log("create api request: "+ data)
    urls.BusinessCenter.create(data)
    .then(res => {
        dispatch({
            type: ACTION_TYPES.CREATE,
            payload: res.data.data
        })
        onSuccees()
    })
    .catch(err => console.log(err))
}

export const update = (id, data, onSuccees) => dispatch => {
    console.log("post api request: "+ data)
    urls.BusinessCenter.update(id, data).then(res => {
        dispatch({
            type: ACTION_TYPES.UPDATE,
            payload: {id, ...res.data.data}
        })
        onSuccees()
    })
    .catch(err => console.log(err))
}

export const erase = (id, onSuccees) => dispatch => {
    console.log("erase api request: ")
    urls.BusinessCenter.delete(id).then(res => {
        dispatch({
            type: ACTION_TYPES.DELETE,
            payload: id
        })
        onSuccees()
    })
    .catch(err => console.log(err))
}