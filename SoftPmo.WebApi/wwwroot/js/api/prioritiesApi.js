import apiClient from './apiClient.js';

class PrioritiesApi {
    constructor() {
        this.endpoint = '/Priorities';
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

const prioritiesApi = new PrioritiesApi();
export default prioritiesApi;
