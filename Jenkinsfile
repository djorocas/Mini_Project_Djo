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
              withCredentials([usernamePassword(credentialsId: 'MyID', passwordVariable: '43a6633c950e60b378e54b7ee4caf3fa6d6daf43', usernameVariable: 'djorocas')]) {
                sh("git remote rm origin")
                sh("git remote add origin git@github.com:djorocas/Mini_Project_Djo.git")
                sh("git branch -D master")
                sh("git checkout -b master")
                sh("git add .")
                sh("git commit -am 'Testing'")
                sh("echo About to push")
                sh('git push origin master:master')
              }
        }
    }
  }
}
