import { test, rm } from 'shelljs'

const targetDirs = [
  '../docroot',
  '../VHActorManager/bin/Debug/net7.0-windows/docroot',
  '../VHActorManager/bin/Release/net7.0-windows/docroot'
]

for (let i = 0; i < targetDirs.length; i++) {
  const targetDir = targetDirs[i]

  if (!test('-d', targetDir)) {
    console.log(`target directory is not found: ${targetDir}`)
    continue
  }

  rm('-r', targetDir + '/*')
}
