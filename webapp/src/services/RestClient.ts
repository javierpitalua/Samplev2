import axios from "axios"

const serverUrl = "http://localhost:5000/"
export class RestClient {
    public get<T>(url: string, params: any): Promise<T> {
        return new Promise ((resolve, reject) => {
            axios.get<T>(serverUrl + url, {params})
            .then(o => resolve(o.data))
        });
    }

    public post<T>(url: string, payload: any): Promise<T> {
        return new Promise ((resolve, reject) => {
            axios.post<T>(serverUrl + url, payload)
            .then(o => resolve(o.data))
        });
    }
}

let restClient = new RestClient()

export default restClient