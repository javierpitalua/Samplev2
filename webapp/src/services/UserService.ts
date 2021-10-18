import { Office } from "./OfficeService";
import restClient from "./RestClient";

export class Role {
    constructor(public id: string, public name: string) {}
}

export class UserRole {
    constructor(public id: string, public role: Role) {}
}

export class User {
    constructor(
        public id: string,
        public office: Office, 
        public login: string, 
        public roles: UserRole[]) {}
}

export class UserService {
    public async getUsers(officeIds: string[]): Promise<User[]> {        
        let ids = ''
        officeIds.forEach(element => {
            ids += element + ','
        });

        let items = await restClient.post<User[]>("users/getUsers", {officeIds})
        return items
    }
}

let userService = new UserService()
export default userService