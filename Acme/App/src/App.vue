<template>
    <div id="app">
        <router-view/>
    </div>
</template>

<script>
    import EnterDraw from './components/EnterDraw.vue'
    export default {
        name: 'App',
        components: {
            EnterDraw
        }
    }
</script>

<style>

</style>
