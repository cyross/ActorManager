import { createApp } from 'vue';
import { createPinia } from 'pinia';

import App from './App.vue';
import router from './router';
import 'bootstrap';

import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import './assets/main.css';

console.log(`[[VITE_ENV=${import.meta.env.VITE_ENV}]]`)

const app = createApp(App);

app.use(createPinia());
app.use(router);

app.mount('#app');
