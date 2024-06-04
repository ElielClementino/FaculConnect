<template>
    <v-app-bar
        color="#FFFFFF"
        fixed
        class="nav-items"
    >
        <v-app-bar-nav-icon color="#000000">
            <v-icon x-large>mdi-bell-outline</v-icon>
        </v-app-bar-nav-icon>
        <v-app-bar-nav-icon color="#000000">
            <v-icon x-large>mdi-account-circle-outline</v-icon>
        </v-app-bar-nav-icon>

    </v-app-bar>
</template>

<style scoped>
.nav-items {
    display:flex;
    align-items: end;
    justify-content: flex-end;
}

</style>
