import {createApp} from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from "./router/index.ts";
import {createPinia} from 'pinia'

const pinia = createPinia()

createApp(App)
    .use(pinia)
    .use(router)
    .use(vuetify)
    .mount('#app')
