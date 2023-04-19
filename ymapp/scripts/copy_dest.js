const shell = require('shelljs');

const sourceDir = './dist';
const targetDirs = ['../docroot', '../VHActorManager/bin/Debug/net7.0-windows/docroot', '../VHActorManager/bin/Release/net7.0-windows/docroot'];

if (!shell.test('-d', sourceDir))
{
  console.log('source directory is not found')
  process.exit(1);
}

for(let i=0; i<targetDirs.length; i++) {
  const targetDir = targetDirs[i];

  if (!shell.test('-d', targetDir))
  {
    console.log(`target directory is not found: ${targetDir}`)
    continue;
  }

  shell.cp('-r', sourceDir + "/*", targetDir);
}
