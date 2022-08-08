<template>
  <v-card color="rgb(22,31,44, 0.7)">
    <v-container>
      <v-file-input
          placeholder="Upload your documents"
          label="File input"
          accept=".zip,.rar"
          multiple
          prepend-icon="mdi-paperclip"
      >
        <template v-slot:selection="{ fileNames }">
          <template v-for="fileName in fileNames" :key="fileName">
            <v-chip
                size="small"
                label
                color="primary"
                class="mr-2"
            >
              {{ fileName }}
            </v-chip>
          </template>
        </template>
      </v-file-input>
    </v-container>
  </v-card>
</template>

<script setup lang="ts">
</script>

<style scoped>

</style>