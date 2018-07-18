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

    stage('Push to remote Brnach') {
      steps {
        sh 'git add .'
        sh "git commit -am 'added artifacts'"
        sh 'git config user.email "djobukata@gmail.com"'
        sh 'git config user.name "djorocas"'
        sh 'git push origin master'
      }
    }
  }

}
