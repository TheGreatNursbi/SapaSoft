import React, {useState, useEffect} from "react";

const useForm = (initialFieldValues, SetCurrentId) => {
    const [selectedDate, setSelectedDate] = useState(new Date('2020-01-01T21:11:54'));
    const [values, setValues] = useState(initialFieldValues)

    const handleInputChange = e => {
        const {name, value} = e.target
        const fieldValue = {[name]: value}
        setValues({
            ...values,
            ...fieldValue
        })
        setSelectedDate(getRightDate(selectedDate))
    }

    const resetForm = () => {
        setValues({
            ...initialFieldValues
        })
        SetCurrentId(0)
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

    return {
        selectedDate,
        setSelectedDate,
        values,
        setValues,
        resetForm,
        handleInputChange,
        getRightDate
    };
}

export default useForm;