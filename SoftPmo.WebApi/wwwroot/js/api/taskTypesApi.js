import apiClient from './apiClient.js';

class TaskTypesApi {
    constructor() {
        this.endpoint = '/TaskTypes';
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

const taskTypesApi = new TaskTypesApi();
export default taskTypesApi;
