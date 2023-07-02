import { environment } from "src/environments/environment";

// Aqui se guardan las rutas de la API.
const BASE_URL = `${environment.url}/api`;
export const ApiRouting = {
    api_url: BASE_URL,
    articleStore: 'articleStore',
    articleClient: 'articleClient',
    store: 'store',
    auth: 'auth',
    insert: 'insert',
    update: 'update',
    delete: 'delete',
    getAllProductsPagination: 'getAllByPagination',
    getByPagination: 'getByPagination',
    getCount: 'getCount',
    login: 'login',
    logout: 'logout'

};
