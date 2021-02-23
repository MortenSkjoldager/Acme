<template>
    <div>
        <h1>Submissions</h1>

        <table class="table">
            <thead>
            <tr>
                <th scope="col">First name</th>
                <th scope="col">Last name</th>
                <th scope="col">Email</th>
                <th scope="col">Serial</th>
            </tr>
            </thead>
            <tbody>
                <tr v-for="submission in submissions" :key="submission.SerialNumber.Key">
                    <td>{{submission.FirstName}}</td>
                    <td>{{submission.LastName}}</td>
                    <td>{{submission.Email}}</td>
                    <td>{{submission.SerialNumber.Key}}</td>

                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        name: 'Submissions',
        data() {
            return {
                submissions: [],
                skip: 0,
                take: 100,
                totalCount: 0
            }
        },
        mounted() {
            axios.get(`api/submissions/get/${this.skip}/${this.take}`)
                .then(response => {
                    this.submissions = response.data.Submissions
                    this.totalCount = response.data.TotalCount
                    this.skip = this.skip + this.take
                    this.skip = 10 //load more to begin with and then set it to 10 
                });
        },

        methods: {}
    }
</script>

<style lang="stylus" scoped>

</style>
