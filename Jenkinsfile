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
              sh 'git commit -m "Testing"'
              sh 'git push origin master'
        }
    }
  }
}
