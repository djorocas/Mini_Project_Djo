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
              withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'MyID', usernameVariable: 'djorocas', passwordVariable: 'Cyberjunkie2#']]) {
                sh("${git} config credential.username djorocas")
                sh("${git} config credential.helper '!f() { echo password=Cyberjunkie2#; }; f'")
                sh("GIT_ASKPASS=false ${git} push origin master")
              }
            }
        }
    }
  }
}
