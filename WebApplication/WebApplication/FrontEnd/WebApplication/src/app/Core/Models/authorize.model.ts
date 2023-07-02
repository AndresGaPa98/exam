export interface AuthorizeModel{
    UserName: string;
    Password: string;
}
export interface LoginResponseModel{
    autentificado: boolean;
    accessToken: string;
    userId: string;
    role: string;
}