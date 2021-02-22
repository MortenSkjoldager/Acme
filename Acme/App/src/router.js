import Vue from 'vue'
import Router from 'vue-router'
import EnterDraw from "./components/EnterDraw";
import Submissions from "./components/Submissions";

Vue.use(Router)

export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/enter',
            name: 'enter',
            component: EnterDraw
        },
        {
            path: '/submissions',
            name: 'submissions',
            component: Submissions
        }
    ]
})
