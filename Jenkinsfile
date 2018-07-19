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

    stage('Clone Repo') {
      steps {
        sh 'rm -rf Mini_Project_Djo'
        sh 'git clone https://github.com/djorocas/Mini_Project_Djo.git'
      }
    }

    stage('Copy Artifact') {
      steps {
        dir('cd Mini_Project_Djo'){
          script {
                 step ([$class: 'CopyArtifact',
                 projectName: 'gradle-package-artifacts',
                 filter: "/*.jar",
                 target: 'WebAPI']);
          }
        }
      }
    }
    stage('Push') {
        steps {
              withCredentials([usernamePassword(credentialsId: 'MyID', passwordVariable: 'Cyberjunkie2#', usernameVariable: 'djorocas')]) {
                sh("git add .")
                sh("git commit -am 'Testing'")
                sh("echo About to push")
                sh('git push origin master')
              }
        }
    }
  }
}
