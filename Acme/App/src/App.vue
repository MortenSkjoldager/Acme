<template>
    <div id="app">
        <router-view/>
    </div>
</template>

<script>
    import Vue from 'vue'
    import EnterDraw from './components/EnterDraw.vue'
    import Submissions from "./components/Submissions";
    import infiniteScroll from 'vue-infinite-scroll'
    Vue.use(infiniteScroll)
    export default {
        name: 'App',
        components: {
            EnterDraw,
            Submissions
        },
        directives: {
            infiniteScroll
        }
    }
</script>

<style>

</style>
