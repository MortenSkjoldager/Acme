<template>
    <div id="app">
        <router-view/>
    </div>
</template>

<script>
    import EnterDraw from './components/EnterDraw.vue'
    import Submissions from "./components/Submissions";
    export default {
        name: 'App',
        components: {
            EnterDraw,
            Submissions
        }
    }
</script>

<style>

</style>
