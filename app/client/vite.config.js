import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import mkcert from 'vite-plugin-mkcert'
import path from 'path'

export default defineConfig({
  server: {
    https: true
  },
  plugins: [
    react(),
    mkcert()
  ],
  resolve: { 
    alias: { 
      '@': path.resolve(__dirname, './src')
    } 
  }
})