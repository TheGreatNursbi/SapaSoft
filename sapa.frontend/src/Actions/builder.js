import urls from "./api";

export const ACTION_TYPES = {
    CREATE: "CREATE",
    UPDATE: 'UPDATE',
    DELETE: 'DELETE',
    FETCH_ALL: 'FETCH_ALL'
}

export const fetchAll = () => dispatch => {
    urls.Builder.fetchAll()
        .then(response => {
                dispatch({
                    type: ACTION_TYPES.FETCH_ALL,
                    payload: response.data.data
                })
            })
            .catch(err => console.log(err))
}

export const create = (data, onSuccees) => dispatch => {
    urls.Builder.create(data)
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
    urls.Builder.update(id, data).then(res => {
        dispatch({
            type: ACTION_TYPES.UPDATE,
            payload: {id, ...res.data.data}
        })
        onSuccees()
    })
    .catch(err => console.log(err))
}

export const erase = (id, onSuccees) => dispatch => {
    urls.Builder.delete(id).then(res => {
        dispatch({
            type: ACTION_TYPES.DELETE,
            payload: id
        })
        onSuccees()
    })
    .catch(err => console.log(err))
}

