import Vue from 'vue'
import App from './App.vue'
import router from './router'
import 'bootstrap/dist/css/bootstrap.min.css'
import "font-awesome/css/font-awesome.min.css"
import 'popper.js'
import Vuelidate from 'vuelidate'
var css = require('./css/_main.styl');

Vue.use(Vuelidate)
Vue.config.productionTip = false
new Vue({
    router,
    render: h => h(App),
}).$mount('#app')