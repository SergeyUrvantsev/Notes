export class ClientBase {
    protected transformOptions(options: RequestInit) {
        const token = localStorage.getItem('token');
        options.headers = {
            ...options.headers,
            Autorization: 'Bearer ' + token
        };
        return Promise.resolve(options);
    }
}