import axios from "axios";
export function validSerial(value) {

    if (!isValidKey(value)) 
    {
        return false
    }
    
    return axios.get(`/api/serialnumber/validate/${value}`)
        .then(response => {
            // JSON responses are automatically parsed.
            console.log(response.data);
            return response.data.Valid
        });
}

export function validSubmissionKey(value) {
    if (!isValidKey(value))
    {
        return false
    }

    return axios.get(`api/submission/validateSubmissionKey/${value}`)
        .then(response => {
            // JSON responses are automatically parsed.
            return response.data.ActivationCount < 2
        });
}

export function minimumAge(value) {
    return value >= 18
}

function isValidKey(value) {
    let pattern = /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i
    let regex = new RegExp(pattern);

    return regex.test(value)
}
