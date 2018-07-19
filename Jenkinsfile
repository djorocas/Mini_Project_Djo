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

    stage('Commit Artifacts') {
        steps {
              sh 'git remote -v'
              sh 'echo check new remote'
              sh 'git add .'
              sh "git commit -m 'Pushing new data'"
        }
    }

    stage('Push new jar') {
      steps {
        withCredentials([sshUserPrivateKey(credentialsId: 'jenkinsssh', keyFileVariable: 'SSH_KEY')]) {
          sh 'echo ssh -i $SSH_KEY -l git -o StrictHostKeyChecking=no \\"\\$@\\" > local_ssh.sh'
          sh 'chmod +x local_ssh.sh'
          withEnv(['GIT_SSH=local_ssh.sh']) {
              sh 'git push origin HEAD:master'
          }
        }
      }
    }
  }
}
