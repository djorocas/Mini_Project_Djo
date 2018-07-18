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
                sh("git remote rm origin")
                sh("git remote add origin https://djorocas:Cyberjunkie2#@github.com/djorocas/Mini_Project_Djo.git")
                sh("git branch -d master")
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
}
