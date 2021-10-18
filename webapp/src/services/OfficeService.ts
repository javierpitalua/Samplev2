import restClient from "./RestClient";

export class Office {
    constructor(public id: string, public address: string) {}
}

export class OfficeService {
    public async getOffices(pattern: string): Promise<Office[]> {
        return await restClient.get<Office[]>("offices/getOffices", { searchPattern: pattern });
    }
}


let officeService = new OfficeService()
export default officeService