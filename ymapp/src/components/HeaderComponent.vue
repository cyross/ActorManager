<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <div class="container header-view">
    <div class="row">
      <div class="col">
        <nav class="navbar navbar-expand navbar-light bg-light">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
              <RouterLink to="/" class="nav-link active">ホーム画面</RouterLink>
            </li>
            <li class="nav-item">
              <RouterLink to="/actorMaster" class="nav-link">声優マスター管理画面</RouterLink>
            </li>
            <li class="nav-item">
              <RouterLink to="/veMaster" class="nav-link"
                >音声合成エンジンマスター管理画面</RouterLink
              >
            </li>
            <li class="nav-item">
              <RouterLink to="/colorMaster" class="nav-link">色マスター管理画面</RouterLink>
            </li>
            <li class="nav-item">
              <RouterLink to="/sanitizeRe" class="nav-link">セリフサニタイズ管理画面</RouterLink>
            </li>
            <li class="nav-item">
              <RouterLink to="/encodings" class="nav-link"
                >文字エンコードマスター管理画面</RouterLink
              >
            </li>
            <li class="nav-item">
              <RouterLink to="/separators" class="nav-link">区切り文字マスター管理画面</RouterLink>
            </li>
            <li class="nav-item">
              <RouterLink to="/colorList" target="_blank" class="nav-link"
                >色名リスト表示(別窓)</RouterLink
              >
            </li>
          </ul>
        </nav>
      </div>
    </div>
  </div>
</template>
