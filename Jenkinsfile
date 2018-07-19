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
              sh 'git add --all'
              sh 'git show-ref'
              sh "git commit -m 'Pushing new data'"
              sh 'git rev-parse --abbrev-ref HEAD'
              sh 'git push origin HEAD:master'

        }
    }
  }
}
