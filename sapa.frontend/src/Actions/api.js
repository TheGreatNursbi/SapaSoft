import axios from "axios";

const baseUrl = "http://localhost:5000/api/";

const urls = {
    Builder: {
        fetchAll: () => axios.get(baseUrl + 'builder/'),
        fetchById: id => axios.get(baseUrl + 'builder/' + id),
        create: newRecord => axios({
            method: 'post',
            url: baseUrl + 'builder/',
            data: newRecord,
            headers: {'Content-Type': 'application/json; charset=utf-8' }
            }),
        update: (id, updateRecord) => axios.put(baseUrl + 'builder/' + id, updateRecord),
        delete: id => axios.delete(baseUrl + 'builder/' + id)
    },
    BusinessCenter: {
        fetchAll: () => axios.get(baseUrl + 'businessCenter/'),
        fetchById: id => axios.get(baseUrl + 'businessCenter/' + id),
        create: newRecord => axios({
            method: 'post',
            url: baseUrl + 'businessCenter/',
            data: newRecord,
            headers: {'Content-Type': 'application/json; charset=utf-8' }
            }),
        update: (id, updateRecord) => axios.put(baseUrl + 'businessCenter/' + id, updateRecord),
        delete: id => axios.delete(baseUrl + 'businessCenter/' + id)
    }
}
export default urls
