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
              sh 'git remote rm origin'
              sh "git remote add origin https://djorocas:'Cyberjunkie2#'@github.com/djorocas/Mini_Project_Djo.git"
              sh 'echo check new remote'
              sh 'git remote -v'
              sh 'git add .'
              sh "git commit -m 'Pushing new data'"
              sh 'git config user.name'
              sh 'git push origin HEAD:master'

        }
    }
  }
}
