import Vue from 'vue'
import Router from 'vue-router'
import EnterDraw from "./components/EnterDraw";

Vue.use(Router)

export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/enter',
            name: 'enter',
            component: EnterDraw
        }
    ]
})
