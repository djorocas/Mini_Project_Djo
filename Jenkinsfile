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
              withCredentials([usernamePassword(credentialsId: 'MyID', passwordVariable: 'Cyberjunkie2#', usernameVariable: 'djorocas')]) {
                sh("git add .")
                sh("git commit -am 'Testing'")
                sh("echo About to push")
                sh("git remote set-url origin https://github.com/djorocas/Mini_Project_Djo.git")
                sh('git push HEAD:master HEAD:master')
              }
            }
        }
    }
  }
}
