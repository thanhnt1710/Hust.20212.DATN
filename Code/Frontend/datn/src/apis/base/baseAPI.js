import APIConfig from './apiConfig.js';
import axios from 'axios';

var BaseAPIConfig = axios.create({
    baseURL: APIConfig,
    headers: { 'Content-type': 'application/json' }
});

export default class BaseAPI {
    constructor() {
        this.controller = null;
    }

    getAll() {
        return BaseAPIConfig.get(`${this.controller}`);
    }
    
    getById(id) {
        return BaseAPIConfig.get(`${this.controller}/${id}`);
    }

    add(body) {
        return BaseAPIConfig.post(`${this.controller}`, body);
    }

    update(body) {
        return BaseAPIConfig.put(`${this.controller}`, body);
    }

    delete(body) {
        return BaseAPIConfig.delete(`${this.controller}`, body);
    }
}