pipeline {
  agent any
  stages {
    stage('Init'){
      steps {
        echo 'Testing ....'
      }
    }
    stage('Build'){
      steps {
        echo 'Building ....'
      }
    }
    stage('Deploy') {
      steps {
        echo 'Deploying....'
      }
    }

    stage('Copy Artifact') {
      steps {
          script {
                 step ([$class: 'CopyArtifact',
                 projectName: 'gradle-package-artifacts',
                 filter: "**/*.jar",
                 target: 'WebAPI']);
          }
      }
    }

    stage('Push') {
        steps {
              sh 'git remote -v'
              sh 'echo check new remote'
              sh 'git add .'
              sh "git commit -m 'Pushing new data'"
              sh 'git config user.name'
              sh 'git config user.username'
              sh 'git config remote.origin.url'
              sh 'git push origin HEAD:master'

        }
    }
  }
}
