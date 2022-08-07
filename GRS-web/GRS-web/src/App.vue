<template>
  <v-app>
    <v-app-bar
        id="grs-navbar"
        density="compact"
    >
      <template v-slot:prepend>
        <v-app-bar-nav-icon @click="store.changeSideBarVisibility()"></v-app-bar-nav-icon>
      </template>

      <v-spacer/>
      <v-app-bar-title>
        <v-img src="/src/images/GRSwhiteV2.png" width="100" class="mx-auto"></v-img>
      </v-app-bar-title>
      <v-spacer/>

      <template v-slot:append>
        <v-icon>mdi-account-circle</v-icon>
      </template>
    </v-app-bar>

    <v-navigation-drawer v-model="store.sideBar" absolute class="dark-transparent">
      <router-link to="/" class="reset-a">
        <v-list-item prepend-icon="mdi-home">
          Home
        </v-list-item>
      </router-link>
      <router-link to="/forum" class="reset-a">
        <v-list-item prepend-icon="mdi-forum">
          Forum
        </v-list-item>
      </router-link>
      <router-link to="/maps" class="reset-a">
        <v-list-item prepend-icon="mdi-map">
          Maps
        </v-list-item>
      </router-link>
      <router-link to="/clans" class="reset-a">
        <v-list-item prepend-icon="mdi-sitemap">
          Clans
        </v-list-item>
      </router-link>
      <router-link to="/monitor" class="reset-a">
        <v-list-item prepend-icon="mdi-monitor">
          Monitor
        </v-list-item>
      </router-link>
      <router-link to="/donate" class="reset-a">
        <v-list-item prepend-icon="mdi-currency-usd">
          Donate
        </v-list-item>
      </router-link>
    </v-navigation-drawer>
    <v-main class="body">
      <router-view/>
    </v-main>
    <v-footer absolute app="true" width="auto" style="max-height: 50px;" id="grs-footer">
      <v-row>
        <v-col>
          GRS © 2021
        </v-col>
        <v-col cols="auto" class="float-right align-content-end">
          <v-icon>mdi-discord</v-icon>
          <v-icon class="ml-5">mdi-youtube</v-icon>
        </v-col>
      </v-row>
    </v-footer>
  </v-app>
</template>

<script setup lang="ts">
import {useMainStore} from "./stores/main.js";

const store = useMainStore();
</script>

<style lang="scss">
@import "./style/buttons.scss";
@import "./style/site.scss";
@import "./style/colors.scss";


html {
  position: relative;
  min-height: 100%;
  font-size: 14px;
}

@media (min-width: 768px) {
  html {
    font-size: 16px;
  }
}

.body {
  font-family: 'Poppins', Tahoma, Geneva, Verdana, sans-serif;
  background: url('./images/grs-logo.svg') no-repeat center center fixed;
  background-size: cover;
  backdrop-filter: blur(20px);
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.container {
  padding-bottom: 10px;
}

.grs-body {
  padding-left: 0;
  padding-right: 0;
}

#grs-navbar {
  background-color: var(--navbar-color);
}

#grs-footer {
  background-color: var(--navbar-color);
}

.reset-a, .reset-a:visited, .reset-a:focus, .reset-a:active {
  text-decoration: none;
  color: inherit;
  outline: 0;
}

.reset-a:hover {
  color: var(--winter-sky) !important;
}

</style>