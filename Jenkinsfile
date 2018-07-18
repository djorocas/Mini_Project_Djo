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
            script {
              withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'MyID', usernameVariable: 'djorocas', passwordVariable: '44c631a8cd1006e04d9af4b7ebff24523a0dd532']]) {
                sh 'git add .'
                sh 'git config --global user.name "Djo Mwanza"'
                sh 'git config --global user.email "djobukata@gmail.com"'
                sh 'echo About to commit message'
                sh 'git commit -am "Added artifacts"'
                sh 'git remote set-url origin git@github.com:djorocas/Mini_Project_Djo.git'
                sh 'git push origin HEAD:master'
              }
            }
        }
    }
  }
}
