import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue';
import Forum from '../views/Forum.vue';
import Maps from '../views/Maps.vue';
import Clans from '../views/Clans.vue';
import Monitor from '../views/Monitor.vue';
import Donate from '../views/Donate.vue';

export default createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            component: Home,
        },
        {
            path: '/forum',
            component: Forum,
        },
        {
            path: '/maps',
            component: Maps,
        },
        {
            path: '/clans',
            component: Clans,
        },
        {
            path: '/monitor',
            component: Monitor,
        },
        {
            path: '/donate',
            component: Donate,
        },
    ]
})