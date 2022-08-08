<template>
  <v-card color="rgb(22,31,44, 0.7)">
    <Breadcrumbs :breadCrumbsItems="breadCrumbsItems"/>
    <v-text-field hide-details label="Search" append-inner-icon="mdi-magnify"/>
    <v-card color="rgb(22,31,44, 0)">
      <div class="text-center mt-3">
        <router-link :to="path" class="reset-a">
          <v-btn class="rounded-xl btn-submit"
                 append-icon="mdi-feather">
            WRITE NEW THREAD
          </v-btn>
        </router-link>
      </div>
      <div class="text-center mt-4">
        <v-pagination
            rounded="circle"
            size="x-small"
            class="mango"
            :length="15"
            :total-visible="4"
            variant="tonal"
        ></v-pagination>
      </div>
      <div>
        <router-link to="/forum/report-player/name" class="reset-a">
          <v-list-item style="padding-bottom: 0;"
                       title="How to report a player"
          >
            <template v-slot:prepend >
              <v-avatar class="mb-5">
                <v-icon size="x-large" color="white">mdi-newspaper</v-icon>
              </v-avatar>
            </template>

            <template v-slot:subtitle>
              <span>by <span class="font-weight-bold">User</span> 5 Minutes Ago</span>
              <v-divider class="mb-2 "/>
              <span>
              Last Reply by
              <span style="color: blue" class="font-weight-bold">
                User
              </span>
                2 Minutes Ago
            </span>
              <v-divider color="grey" class="mb-2 mt-2"/>
            </template>
          </v-list-item>
        </router-link>

        <router-link to="/forum/report-player/name1" class="reset-a">
          <v-list-item style="padding-bottom: 0;"
                       title="What's new?"
          >
            <template v-slot:prepend >
              <v-avatar class="mb-5">
                <v-icon size="x-large" color="white">mdi-newspaper</v-icon>
              </v-avatar>
            </template>

            <template v-slot:subtitle>
              <span>by <span class="font-weight-bold">User</span> 5 Minutes Ago</span>
              <v-divider class="mb-2 "/>
              <span>
              Last Reply by
              <span style="color: blue" class="font-weight-bold">
                User
              </span>
                2 Minutes Ago
            </span>
              <v-divider color="grey" class="mb-2 mt-2"/>
            </template>
          </v-list-item>
        </router-link>

        <router-link to="/forum/report-player/name2" class="reset-a">
        <v-list-item style="padding-bottom: 0;"
                     title="Reporting ~Lewy~ for abusing"
        >
          <template v-slot:prepend >
            <v-avatar class="mb-5">
              <v-icon size="x-large" color="white">mdi-newspaper</v-icon>
            </v-avatar>
          </template>

          <template v-slot:subtitle>
            <span>by <span class="font-weight-bold">User</span> 5 Minutes Ago</span>
            <v-divider class="mb-2 "/>
            <span>
              Last Reply by
              <span style="color: blue" class="font-weight-bold">
                User
              </span>
                2 Minutes Ago
            </span>
            <v-divider color="grey" class="mb-2 mt-2"/>
          </template>
        </v-list-item>
      </router-link>
        <router-link to="/forum/report-staff/name3" class="reset-a">
          <v-list-item style="padding-bottom: 0;"
                       title="Reporting ~Lewy~ for abusing"
          >
            <template v-slot:prepend >
              <v-avatar class="mb-5">
                <v-icon size="x-large" color="white">mdi-newspaper</v-icon>
              </v-avatar>
            </template>

            <template v-slot:subtitle>
              <span>by <span class="font-weight-bold">User</span> 5 Minutes Ago</span>
              <v-divider class="mb-2 "/>
              <span>
              Last Reply by
              <span style="color: blue" class="font-weight-bold">
                User
              </span>
                2 Minutes Ago
            </span>
              <v-divider color="grey" class="mb-2 mt-2"/>
            </template>
          </v-list-item>
        </router-link>
        
      </div>

      <div class="text-center mt-4">
        <v-pagination
            rounded="circle"
            size="x-small"
            class="mango"
            :length="15"
            :total-visible="4"
            variant="tonal"
        ></v-pagination>
      </div>
    </v-card>
  </v-card>
</template>

<script setup lang="ts">
import {defineProps} from "vue";
import Breadcrumbs from "../../components/breadcrumbs.vue";
import {useRouter} from "vue-router";

const props = defineProps({
  postName: String,
  threadName: String,
  link: String,
});

const router = useRouter();
const path = router.currentRoute.value.fullPath + '/create-thread';

const breadCrumbsItems = [
  {
    text: 'Home',
    disabled: false,
    href: '/',
  },
  {
    text: 'Forum',
    disabled: false,
    href: '/forum',
  },
  {
    text: props.threadName,
    disabled: true,
    href: '/report-player',
    color: "#FF006E",
  },
];
</script>

<style scoped>
.btn-submit {
  color: #fff;
  background-color: #242433;
  border: 1px solid #5BCE00;
}
</style>