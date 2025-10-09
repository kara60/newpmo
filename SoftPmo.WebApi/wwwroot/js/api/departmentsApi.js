import apiClient from './apiClient.js';

class DepartmentsApi {
    constructor() {
        this.endpoint = '/Departments';
    }

    async getAll(params = {}) {
        return await apiClient.get(this.endpoint, params);
    }

    async getById(id) {
        return await apiClient.get(`${this.endpoint}/${id}`);
    }

    async create(data) {
        return await apiClient.post(`${this.endpoint}/Create`, data);
    }

    async update(data) {
        return await apiClient.put(`${this.endpoint}/Update`, data);
    }

    async delete(id) {
        return await apiClient.delete(`${this.endpoint}/${id}`);
    }
}

const departmentsApi = new DepartmentsApi();
export default departmentsApi;
