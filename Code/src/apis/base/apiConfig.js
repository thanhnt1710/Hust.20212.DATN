var APIConfig = {
    development: 'https://localhost:44357/'
}

export default APIConfig[process.env.NODE_ENV];