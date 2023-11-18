import { test, cp } from 'shelljs'

const sourceDir = './dist'
const targetDirs = [
  '../docroot',
  '../VHActorManager/bin/Debug/net7.0-windows/docroot',
  '../VHActorManager/bin/Release/net7.0-windows/docroot'
]

if (!test('-d', sourceDir)) {
  console.log('source directory is not found')
  process.exit(1)
}

for (let i = 0; i < targetDirs.length; i++) {
  const targetDir = targetDirs[i]

  if (!test('-d', targetDir)) {
    console.log(`target directory is not found: ${targetDir}`)
    continue
  }

  cp('-r', sourceDir + '/*', targetDir)
}
