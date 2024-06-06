<template>
    <v-app-bar
        color="#FFFFFF"
        fixed
        class="nav-items text-style "
    >
        <h1 text style="color:#010101;" class="nav-title">{{ NavTitle }}</h1>
        <v-app-bar-nav-icon color="#000000">
            <v-icon x-large>mdi-bell-outline</v-icon>
        </v-app-bar-nav-icon>
        <v-app-bar-nav-icon color="#000000">
            <v-icon x-large>mdi-account-circle-outline</v-icon>
        </v-app-bar-nav-icon>

    </v-app-bar>
</template>
<script>
export default {
    props: {
        NavTitle: {
            type:String,
            required: false,
            default: ''
        }
    },
    computed: {
        showTitle() {
            return this.NavTitle !== '';
        }
  }
}
</script>

<style scoped>
.nav-items {
    display:flex;
    align-items: end;
    justify-content: flex-end;
    padding-right: 10px;
}
.nav-title {
    padding: 100px;
}
.text-style {
    font-family: Poppins, sans-serif;
    font-weight: 900;
}
</style>
