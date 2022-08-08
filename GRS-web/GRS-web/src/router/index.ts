import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue';
import Forum from '../views/Forum.vue';
import Maps from '../views/Maps.vue';
import Clans from '../views/Clans.vue';
import Monitor from '../views/Monitor.vue';
import Donate from '../views/Donate.vue';
import Threads from '../views/Forum/Threads.vue';
import Thread from '../views/Forum/Thread.vue';
import NewThread from '../views/Forum/NewThread.vue';
import Upload from '../views/Maps/Upload.vue';
import MapsView from '../views/Maps/MapsView.vue';
import Testers from '../views/Maps/Testers.vue';

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
            path: '/forum/report-player',
            component: Threads,
            props: {threadName: 'Report Player'}
        },
        {
            path: '/forum/report-staff',
            component: Threads,
            props: {threadName: 'Report Staff'}
        },
        {
            path: '/forum/report-bug',
            component: Threads,
            props: {threadName: 'Report Bug'}
        },
        {
            path: '/forum/:path/:name',
            component: Thread,
            props: (route) => ({threadName: route.params.path.toString().replace('-', ' '), link: route.params.path, title: route.params.name})
        },
        {
            path: '/forum/:path/create-thread',
            component: NewThread,
            props: (route) => ({ threadName: route.params.path.toString().replace('-', ' '), link: route.params.path }),
        },
        {
            path: '/maps',
            component: Maps,
            children: [
                {
                    path: '/maps',
                    component: MapsView
                },
                {
                    path: '/testers',
                    component: Testers
                },
                {
                    path: '/upload',
                    component: Upload
                },
            ]
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